let stores = null;

window.addEventListener('DOMContentLoaded', () => RenderPage(), false);

async function RenderPage() {
    if (!localStorage.getItem("Lang")) {
        await ReadLanguage();
    }

    await SetMode();
    await CheckMode();
    const lang = localStorage.getItem("Lang");
    document.getElementById('addStore').innerHTML = Translation("AddStore", lang);
    document.getElementById('productCategories').innerHTML = Translation("ProductCategories", lang);

    await fetch('https://localhost:7233/AllBasicData')
        .then(data => data.json())
        .then(data => {
            if (data) {
                document.getElementById('StoresText').innerHTML = Translation("StoresText", lang);
                data.forEach((element) => CreateStoreButton(element))
            }
            else {
                document.getElementById('StoresText').innerHTML = Translation("StoresTextNotFound", lang);
            }
        })
        .catch((error) => {
            console.error(error)
        });
}

function CreateStoreButton(item, index) {
    var buttons = document.getElementById('stores');
    var button1 = document.createElement('button');
    button1.type = 'button';
    button1.className = 'btn btn-primary';
    button1.style.marginRight = "10px"
    button1.value = item.name;
    button1.innerHTML = item.name;

    button1.onclick = () => { Redirect('BrowseStore.html', 'StoreId', item.id) }
    buttons.appendChild(button1);
}