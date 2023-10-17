class BenDataBinder {
    constructor(objName, obj) {
        if (!objName) {
            throw 'objName can not be empty';
        }
        this.obj = this.#InitDataBinding(objName, obj);
    }

    Destroy = () => {
        Object.keys(this.obj).forEach(prop => {
            Reflect.set(this.obj, prop, '');
        });
    }

    Map = (srcObj) => {
        Object.keys(srcObj).forEach(prop => {
            Reflect.set(this.obj, prop, srcObj[prop]);
        });
    }

    #InitDataBinding = (objName, obj) => {
        Object.keys(obj).forEach(prop => {
            this.#Render(objName, prop, obj[prop]);
        });
        var obj_proxy = new Proxy(obj, {
            set: (target, prop, value) => {
                target[prop] = value;
                this.#Render(objName, prop, value);
            }
        });
        return obj_proxy;
    }

    #Render = (objName, prop, value) => {
        Array.from(document.querySelectorAll(`[data-ben-binder="${objName}.${prop}"], [data-ben-commuter="${objName}.${prop}"]`)).forEach(e => {
            if(e.getAttribute('data-ben-commuter-listener') != objName){
                e.addEventListener('change', () => {
                    if (e.getAttribute('type') == 'checkbox') {
                        Reflect.set(this.obj, prop, e.checked ? e.value : '');
                    }
                    else {
                        Reflect.set(this.obj, prop, e.value);
                    }
                });
                e.setAttribute('data-ben-commuter-listener', objName);
            }

            if (e.tagName === 'INPUT' || e.tagName === 'SELECT') {
                switch (e.getAttribute('type')) {
                    case 'radio':
                    case 'checkbox':
                        e.checked = e.value == value ? true : false;
                        break;
                    default:
                        e.value = value;
                        break;
                }
            }
            else {
                e.innerText = value;
            }
        });
    }
}
