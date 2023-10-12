class BenValidator {

    constructor({ selector = '.ben-valid'
        , pass = () => { throw 'did not set pass as a function' }
        , fail = () => { throw 'did not set fail as a function' }
    } = {}) {
        this.selector = selector;
        this.pass = pass;
        this.fail = fail;
    }

    valid = () => {
        var pass = document.querySelectorAll(this.selector).values().every((e) => {
            if (e.getAttribute('data-ben-required') === 'true' && !this.#requiredValid(e)) {
                this.fail(e, 'required');
                return false;
            }
            if (!this.#typeValid(e)) {
                this.fail(e, e.getAttribute('data-ben-typeValid'));
                return false;
            }
            return true;
        });
        if (pass) {
            this.pass();
        }
    };

    #requiredValid = (e) => {
        switch (e.getAttribute('type')) {
            case 'radio':
                var name = e.getAttribute('name');
                if (!document.querySelector(`input[name="${name}"]:checked`)) {
                    return false;
                }
                break;
            case 'checkbox':
                var name = e.getAttribute('name');
                var min_checked = e.getAttribute('data-ben-min-checked') ?? '1';
                if (document.querySelectorAll(`input[name="${name}"]:checked`).length < min_checked) {
                    return false;
                }
                break;
            default:
                if (!e.value) {
                    return false;
                }
                break;
        }
        return true;
    }

    #typeValid = (e) => {
        var valid = true;
        switch (e.getAttribute('data-ben-typeValid')) {
            case 'email':
                valid = String(e.value).toLowerCase().match(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/) != null;
                break;
            case 'decimal':
                var digit = e.getAttribute('data-ben-digit').split(',');
                var pattern = digit[1] === '0' ? `^\\d{1,${digit[0]}}?$` : `^\\d{1,${digit[0]}}(\\.\\d{1,${digit[1]}})?$`;
                valid = String(e.value).match(pattern) != null;
                break;
            case 'phone':
                valid = String(e.value).match(/^\d{10,10}?$/) != null;
                break;
        }
        return valid;
    }
}
