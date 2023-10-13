class BenDataBinder {

    constructor(obj) {
        this.obj = this.#InitDataBinding(obj);
    }

    #InitDataBinding = (obj) => {
        Object.keys(obj).forEach(prop => {
            this.#Render(prop, obj[prop]);
        });

        var obj_proxy = new Proxy(obj, {
            set: (target, prop, value, receiver) => {
                this.#Render(prop, value);
            }
        });
        return obj_proxy;
    }

    #Render = (prop, value) => {
        Array.from(document.querySelectorAll(`[data-ben-binder="${prop}"]`)).forEach(e => {
            if (e.tagName === 'INPUT') {
                switch (e.getAttribute('type')) {
                    case 'radio':
                        var tar = document.querySelector(`input[type="radio"][name="${e.getAttribute('name')}"][value="${value}"]`);
                        if (tar) {
                            tar.checked = true;
                        }
                        break;
                    case 'checkbox':
                        Array.from(document.querySelectorAll(`input[type="checkbox"][value="${value}"][data-ben-binder="${prop}"]`)).forEach(e => {
                            e.checked = true;
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
}