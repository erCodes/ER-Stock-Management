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


function Translation(key) {
    const lang = navigator.language;

    let en = new Map();
    en.set("AddStore", "Add store");
    en.set("ProductCategories", "Product Categories");
    en.set("StoresText", "Select Store to view its products");
    en.set("StoresTextNotFound", "No stores found. Add new one to continue.");
    en.set("", "");
    en.set("", "");
    en.set("", "");

    let fi = new Map();
    fi.set("AddStore", "Lisää kauppa");
    fi.set("ProductCategories", "Tuotekategoriat");
    fi.set("StoresText", "Valitse kauppa katsoaksesi sen tuotteita tai lisää uusi");
    fi.set("StoresTextNotFound", "Kauppoja ei löytynyt. Lisää uusi jatkaaksesi.");
    fi.set("", "");
    fi.set("", "");


    if (lang == "en") {
        const enTranslation = en.get(key);

        if (!enTranslation || enTranslation == null) {
            return key + ": not found";
        }

        return enTranslation;
    }

    else if (lang == "fi") {
        const fiTranslation = fi.get(key);

        if (!fiTranslation || fiTranslation == null) {
            return key + ": not found";
        }

        return fiTranslation;
    }

    else {
        return "LANGUAGE ERROR";
    }
}