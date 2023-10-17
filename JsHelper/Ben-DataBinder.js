class BenDataBinder {

    constructor(objName, obj) {
        this.obj = this.#InitDataBinding(objName, obj);
    }

    Destroy = () => {
        Object.keys(this.obj).forEach(prop => {
            Reflect.set(this.obj, prop, '');
        });
    }

    #InitDataBinding = (objName, obj) => {
        Object.keys(obj).forEach(prop => {
            this.#addCoummuter(objName, prop);
            this.#Render(objName, prop, obj[prop]);
        });
        var obj_proxy = new Proxy(obj, {
            set: (target, prop, value, receiver) => {
                target[prop] = value;
                this.#Render(objName, prop, value);
            }
        });
        return obj_proxy;
    }

    #Render = (objName, prop, value) => {
        Array.from(document.querySelectorAll(`[data-ben-binder="${objName}.${prop}"], [data-ben-commuter="${objName}.${prop}"]`)).forEach(e => {
            if (e.tagName === 'INPUT') {
                switch (e.getAttribute('type')) {
                    case 'radio':
                        var tar = document.querySelector(`input[type="radio"][name="${e.getAttribute('name')}"][value="${value}"]`);
                        var c_tar = document.querySelector(`input[type="radio"][name="${e.getAttribute('name')}"]:checked`);
                        if (tar) {
                            tar.checked = true;
                        }
                        else if (c_tar) {
                            c_tar.checked = false;
                        }
                        break;
                    case 'checkbox':
                        e.checked = e.value == value ? true : false;
                        break;
                    default:
                        e.value = value;
                        break;
                }
            }
            else if (e.tagName === 'SELECT') {
                e.value = value;
            }
            else {
                e.innerText = value;
            }
        });
    }

    #addCoummuter = (objName, prop) => {
        Array.from(document.querySelectorAll(`[data-ben-commuter="${objName}.${prop}"]`)).forEach(e => {
            if (e.tagName !== 'INPUT' && e.tagName !== 'SELECT') {
                throw 'data-ben-commuter can only be set on input and select tag';
            }
            e.addEventListener('change', () => {
                if (e.getAttribute('type') == 'checkbox') {
                    Reflect.set(this.obj, prop, e.checked ? e.value : '');
                }
                else {
                    Reflect.set(this.obj, prop, e.value);
                }
            });
        });
    }
}
