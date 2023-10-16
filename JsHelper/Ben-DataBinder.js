class BenDataBinder {

    constructor(objName, obj) {
        this.obj = this.#InitDataBinding(objName, obj);
    }

    #InitDataBinding = (objName, obj) => {
        Object.keys(obj).forEach(prop => {
            this.#addCoummuter(objName, obj, prop);
            this.#Render(objName, prop, obj[prop]);
        });

        var obj_proxy = new Proxy(obj, {
            set: (target, prop, value, receiver) => {
                this.#Render(prop, value);
                target[prop] = value;
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
                    /*
                    case 'checkbox':
                        Array.from(document.querySelectorAll(`input[type="checkbox"][name="${e.getAttribute('name')}"]`)).forEach((cb) => {
                            cb.checked = cb.getAttribute('value') == value ? true : false;
                        });
                        break;
                    */
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

    #addCoummuter = (objName, obj, prop) => {
        Array.from(document.querySelectorAll(`[data-ben-commuter="${objName}.${prop}"]`)).forEach(e => {
            if (e.tagName !== 'INPUT' && e.tagName !== 'SELECT' || e.getAttribute('type') == 'checkbox') {
                throw 'data-ben-commuter can only set on input(beside checkbox) or select';
            }
            e.addEventListener('change', () => {
                obj[prop] = e.value;
                this.#Render(prop, e.value);
            });
        });
    }
}
