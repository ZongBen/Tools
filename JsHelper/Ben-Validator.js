class BenValidator {
    constructor() { }
    /*
    驗證input或select是否有值(checkbox除外)
    obj = {
        selector, //選擇器
        pass(), //通過時執行的function
        fail(element) //失敗時執行的function, element為當下失敗的HTML元素
    }
    */
    requiredValid = (obj) => {
        var pass = document.querySelectorAll(obj.selector).values().every((e) => {
            switch (e.getAttribute('type')) {
                case 'radio':
                    var name = e.getAttribute('name');
                    if (!document.querySelector(`input[name="${name}"]:checked`)) {
                        obj.fail(e);
                        return false;
                    }
                    break;
                default:
                    if (!e.value) {
                        obj.fail(e);
                        return false;
                    }
                    break;
            }
            return true;
        });
        if (pass) {
            obj.pass();
        }
    };

    typeValid = () => {
        document.querySelectorAll('input').values().filter(e => e.getAttribute('data-ben-typeValid') && e.value).every((e) => {
            switch (e.getAttribute('data-ben-typeValid')) {
                case 'email':
                    var pass = String(e.value).toLowerCase().match(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
                    if (!pass) {
                        return false;
                    }
                    break;
                case 'decimal':
                    var digit = e.getAttribute('data-ben-digit').split(',');
                    var pattern;
                    if (digit[1] == 0) {
                        pattern = `^\\d{1,${digit[0]}}?$`;
                    }
                    else {
                        pattern = `^\\d{1,${digit[0]}}(\\.\\d{1,${digit[1]}})?$`;
                    }
                    var pass = String(e.value).match(pattern);
                    if (!pass) {
                        return false;
                    }
                    break;
                case 'text':
                    
                    break;
            }
            return true;
        });
    };
}