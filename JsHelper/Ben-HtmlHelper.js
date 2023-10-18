class BenSelectHelper {
    #defaultOption;
    #selector;
    #options;

    constructor(selector, {
        data = [],
        defaultOption = '',
        options = {
            valueField: 'Value',
            textField: 'Text'
        }
    } = {}) {
        this.data = data;
        this.#selector = selector;
        this.#defaultOption = defaultOption;
        this.#options = options;
        this.#render();
    }

    bind = (data) => {
        this.data = data;
        this.#render();
    }

    #render = () => {
        Array.from(document.querySelectorAll(this.#selector)).forEach(e => {
            if (e.tagName !== 'SELECT') {
                throw 'tagName of the element must be SELECT';
            }
            e.replaceChildren();

            if (this.#defaultOption) {
                e.appendChild(this.#createOption('', this.#defaultOption));
            }

            this.data.forEach(opt => {
                e.appendChild(this.#createOption(opt[this.#options.valueField], opt[this.#options.textField]));
            });
        });
    }

    #createOption = (value, text) => {
        var opt = document.createElement('option');
        opt.setAttribute('value', value);
        opt.innerText = text;
        return opt;
    }
}