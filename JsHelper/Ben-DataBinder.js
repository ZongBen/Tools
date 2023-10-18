class BenDataBinder {
    constructor(objName, obj) {
        if (!objName) {
            throw 'objName can not be empty';
        }
        this.obj = this.#initDataBinding(objName, obj);
    }

    empty = () => {
        Object.keys(this.obj).forEach(prop => {
            Reflect.set(this.obj, prop, '');
        });
    }

    map = (srcObj) => {
        Object.keys(srcObj).forEach(prop => {
            Reflect.set(this.obj, prop, srcObj[prop]);
        });
    }

    #initDataBinding = (objName, obj) => {
        Object.keys(obj).forEach(prop => {
            this.#render(objName, prop, obj[prop]);
        });
        return new Proxy(obj, {
            set: (target, prop, value) => {
                target[prop] = value;
                this.#render(objName, prop, value);
            }
        });
    }

    #render = (objName, prop, value) => {
        Array.from(document.querySelectorAll(`[data-ben-binder="${objName}.${prop}"], [data-ben-commuter="${objName}.${prop}"]`)).forEach(e => {
            if (e.getAttribute('data-ben-commuter') && e.getAttribute('data-ben-commuter-listener') != objName) {
                if (e.tagName !== 'INPUT' && e.tagName !== 'SELECT') {
                    throw 'data-ben-commuter can only set on INPUT and SELECT';
                }
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
