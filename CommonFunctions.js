/*Refactor path part*/
function Redirect(file, parameterKey = null, parameterValue = null) {
    let href = window.location.href;
    let path = href.substring(0, href.lastIndexOf('/')) + "/";
    let page = path.concat(file)

    if (parameterKey && parameterValue) {
        localStorage.setItem(parameterKey, parameterValue);
    }

    window.location.href = page;
}