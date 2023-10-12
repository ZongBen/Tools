class BenValidator {

    constructor() { }

    valid = (obj) => {
        let pass = document.querySelectorAll(obj.selector).values().every((e) => {
            if (e.getAttribute('data-ben-required') === 'true' && !this.#requiredValid(e)) {
                obj.fail(e, 'required');
                return false;
            }
            if (!this.#typeValid(e)) {
                obj.fail(e, e.getAttribute('data-ben-typeValid'));
                return false;
            }
            return true;
        });
        if (pass) {
            obj.pass();
        }
    };

    #requiredValid = (e) => {
        switch (e.getAttribute('type')) {
            case 'radio':
                let name = e.getAttribute('name');
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
        let isvalid = true;
        switch (e.getAttribute('data-ben-typeValid')) {
            case 'email':
                isvalid = String(e.value).toLowerCase().match(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/) != null;
                break;
            case 'decimal':
                let digit = e.getAttribute('data-ben-digit').split(',');
                let pattern = digit[1] === '0' ? `^\\d{1,${digit[0]}}?$` : `^\\d{1,${digit[0]}}(\\.\\d{1,${digit[1]}})?$`;
                isvalid = String(e.value).match(pattern) != null;
                break;
            case 'phone':
                isvalid = String(e.value).match(/^\d{10,10}?$/) != null;
                break;
        }
        return isvalid;
    }
}
