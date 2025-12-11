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

function ReadLanguage() {
    const lang = navigator.language;
    if (lang == "fi") {
        localStorage.setItem("Lang", "fi");
    }
    else {
        localStorage.setItem("Lang", "en");
    }
}

function ChangeLanguage(lang) {
    localStorage.setItem("Lang", lang);
    location.reload();
}


function Translation(key, lang) {
    let en = new Map();
    // Index
    en.set("AddStore", "Add store");
    en.set("ProductCategories", "Product Categories");
    en.set("StoresText", "Select Store to view its products");
    en.set("StoresTextNotFound", "No stores found. Add new one to continue.");
    // ProductCategories
    en.set("CategoryInfoText", "Add, modify or delete product categories here");
    en.set("CategoryGetFail", "Failed to get categories.");
    en.set("CategoryGetNotFound", "There are no categories. Please add new one to continue");
    en.set("Modify", "Modify");
    en.set("DeleteCategory", "Delete category?");
    en.set("Delete", "Delete");
    en.set("CategoryPostFail", "Failed to add new category");
    en.set("CategoryPutFail", "Failed to modify category");
    en.set("CategoryDeleteFail", "Failed to delete category");
    en.set("CategoryName", "Category Name");
    en.set("AddNew", "Add new");
    en.set("", "");
    en.set("", "");


    let fi = new Map();
    // Index
    fi.set("AddStore", "Lisää kauppa");
    fi.set("ProductCategories", "Tuotekategoriat");
    fi.set("StoresText", "Valitse kauppa katsoaksesi sen tuotteita tai lisää uusi");
    fi.set("StoresTextNotFound", "Kauppoja ei löytynyt. Lisää uusi jatkaaksesi.");
    // ProductCategories
    fi.set("CategoryInfoText", "Lisää, muokkaa tai poista tuotekategorioita täällä");
    fi.set("CategoryGetFail", "Ei onnistuttu hakemaan kategorioita");
    fi.set("CategoryGetNotFound", "Kategorioita ei ole. Lisää uusi jatkaaksesi.");
    fi.set("Modify", "Muokkaa");
    fi.set("DeleteCategory", "Poista kategoria?");
    fi.set("Delete", "Poista");
    fi.set("CategoryPostFail", "Ei onnistuttu lisäämään kategoriaa");
    fi.set("CategoryPutFail", "Ei onnistuttu muokkaamaan kategoriaa");
    fi.set("CategoryDeleteFail", "Ei onnistuttu oistamaan kategoriaa");
    fi.set("CategoryName", "Kategorian Nimi");
    fi.set("AddNew", "Lisää uusi");
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