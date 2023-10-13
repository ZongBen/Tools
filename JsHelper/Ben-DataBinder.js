class BenDataBinder {

    constructor(obj) {
        this.obj = this.#InitDataBinding(obj);
    }

    #InitDataBinding = (obj) => {
        Object.keys(obj).forEach(prop => {
            this.#addCoummuter(prop);
            this.#Render(prop, obj[prop]);
        });

        var obj_proxy = new Proxy(obj, {
            set: (target, prop, value, receiver) => {
                this.#Render(prop, value);
                target[prop] = value;
            }
        });
        return obj_proxy;
    }

    #Render = (prop, value) => {
        var query_binder = `[data-ben-binder="${prop}"]`;
        var query_commuter = `[data-ben-commuter="${prop}"]`;

        Array.from(document.querySelectorAll(`${query_binder}, ${query_commuter}`)).forEach(e => {
            if (e.tagName === 'INPUT') {
                switch (e.getAttribute('type')) {
                    case 'radio':
                        var tar = document.querySelector(`input[type="radio"][name="${e.getAttribute('name')}"][value="${value}"]`);
                        if (tar) {
                            tar.checked = true;
                        }
                        break;
                    case 'checkbox':
                        Array.from(document.querySelectorAll(`input[type="checkbox"]${query_binder}, input[type="checkbox"]${query_commuter}`)).forEach((cb) => {
                            cb.checked = cb.getAttribute('value') == value ? true : false;
                        });
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

    #addCoummuter = (prop) => {
        Array.from(document.querySelectorAll(`[data-ben-commuter="${prop}"]`)).forEach(e => {
            e.addEventListener('change', () => {
                
            });
        });
    }
}
