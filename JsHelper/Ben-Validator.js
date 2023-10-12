class BenValidator {

    constructor() { }

    valid = (obj) => {
        var pass = document.querySelectorAll(obj.selector).values().every((e) => {
            if (e.getAttribute('data-ben-required') === 'true' && !this.#requiredValid(e)) {
                obj.requiredValidFail(e);
                return false;
            }
            if (!this.#typeValid(e)) {
                obj.typeValidFail(e);
                return false;
            }
            return true;
        });
        if (pass) {
            obj.validPass();
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
            default:
                if (!e.value) {
                    return false;
                }
                break;
        }
        return true;
    }

    #typeValid = (e) => {
        switch (e.getAttribute('data-ben-typeValid')) {
            case 'email':
                var pass = String(e.value).toLowerCase().match(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
                if (!pass) {
                    return false;
                }
                break;
            case 'decimal':
                var digit = e.getAttribute('data-ben-digit').split(',');
                var pattern = digit[1] === '0' ? `^\\d{1,${digit[0]}}?$` : `^\\d{1,${digit[0]}}(\\.\\d{1,${digit[1]}})?$`;
                var pass = String(e.value).match(pattern);
                if (!pass) {
                    return false;
                }
                break;
            case 'phone':
                var pass = String(e.value).match(/^\d{10,10}?$/);
                if (!pass) {
                    return false;
                }
                break;
        }
        return true;
    }
}
