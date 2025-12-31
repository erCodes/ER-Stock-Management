let storeAndData;
let categories = [];
let counter = 0;
let lang = "";

document.addEventListener('DOMContentLoaded', () => RenderPage(), false);

async function RenderPage() {
    lang = localStorage.getItem("Lang");
    await CheckMode();

    document.getElementById("productsNameTitle").innerHTML = Translation("ProductsNameTitle", lang);
    document.getElementById("amountInStockTitle").innerHTML = Translation("AmountInStockTitle", lang);
    document.getElementById("categoriesTitle").innerHTML = Translation("CategoriesTitle", lang);
    document.getElementById("modifiedTitle").innerHTML = Translation("ModifiedTitle", lang);
    document.getElementById("mainPage").innerHTML = Translation("MainPage", lang);
    document.getElementById("newProductButton").value = Translation("AddNew", lang);
    document.getElementById("NewName").setAttribute("placeholder", Translation("ProductsName", lang));
    document.getElementById("NewAmount").setAttribute("placeholder", Translation("AmountInStock", lang));

    storeAndData = JSON.parse(localStorage.getItem("StoreAndProducts"));
    await GetAllCategories();
    categories = JSON.parse(localStorage.getItem("Categories"));

    await NewCategoryLabels();

    if (storeAndData['products']) {
        storeAndData['products'].forEach((element, index) => CreateProductInfo(element, index));
    }
}

function CreateProductInfo(element, index) {
    const tBody = document.getElementById('table');
    const row = document.createElement('tr');
    const rowId = 'product' + index;
    row.id = rowId;
    tBody.appendChild(row);

    const modifyCell = document.createElement('td');
    const modifyCellId = 'ModifyCell' + index;
    modifyCell.id = modifyCellId;
    row.appendChild(modifyCell);

    const storeId = localStorage.getItem("StoreId");

    const deleteButton = document.createElement('button');
    deleteButton.type = 'button';
    deleteButton.className = 'btn btn-danger';
    deleteButton.innerHTML = Translation("Delete", lang);
    deleteButton.onclick = () => { DeleteProduct(storeId, element['id']) };
    modifyCell.appendChild(deleteButton);

    const modifyButton = document.createElement('button');
    modifyButton.type = 'button';
    modifyButton.className = 'btn btn-primary';
    modifyButton.style.marginLeft = "10px";
    modifyButton.style.marginRight = "10px";
    modifyButton.innerHTML = Translation("Modify", lang);
    modifyButton.onclick = () => { ModifyProduct(storeId, element, index) };
    modifyCell.appendChild(modifyButton);

    const productName = document.createElement('input');
    productName.type = 'text';
    productName.id = "ProductName" + index;
    productName.value = element['name'];
    productName.maxLength = 100;
    modifyCell.appendChild(productName);

    const amountCell = document.createElement('td');
    row.appendChild(amountCell);

    const amount = document.createElement('input');
    amount.type = 'text';
    amount.id = "Amount" + index;
    amount.value = element['inStock'];
    amountCell.appendChild(amount);

    const categoryCell = document.createElement('td');
    categoryCell.id = 'categoryCell' + index;
    row.appendChild(categoryCell);

    for (const entry of categories) {
        var catLabel = document.createElement("label");
        catLabel.setAttribute("for", counter);
        catLabel.textContent = entry['name'];
        catLabel.style.paddingLeft = "10px"
        catLabel.style.paddingRight = "2px"
        categoryCell.appendChild(catLabel);

        var catCheckbox = document.createElement("input");
        catCheckbox.type = "checkbox";
        catCheckbox.className = "form-check-input";
        catCheckbox.id = counter;
        catCheckbox.value = entry['id'];

        const categoryIds = Array.from(element['categoryIds']);

        if (categoryIds.length != 0) {
            for (const id of categoryIds) {
                if (id == entry['id']) {
                    catCheckbox.checked = true;
                }
            }
        }

        categoryCell.appendChild(catCheckbox);
        counter++;
    }

    const timestampCell = document.createElement('td');

    let currentDate = new Date(element['timestamp']).toLocaleDateString("en-GB").toString()
    let currentTime = new Date(element['timestamp']).toLocaleTimeString("en-GB").toString();
    let displayed = currentDate + " " + currentTime;

    timestampCell.textContent = displayed;
    row.appendChild(timestampCell);
}

async function NewCategoryLabels() {
    let newCatCounter = 0;
    const newCategories = document.getElementById("NewCategories");
    for (const entry of categories) {
        var catLabel = document.createElement("label");
        const catId = 'NewCat' + newCatCounter;
        catLabel.setAttribute("for", catId);
        catLabel.textContent = entry['name'];
        catLabel.style.paddingLeft = "10px"
        catLabel.style.paddingRight = "2px"
        newCategories.appendChild(catLabel);

        var catCheckbox = document.createElement("input");
        catCheckbox.type = "checkbox";
        catCheckbox.className = "form-check-input";
        catCheckbox.id = "NewCat" + newCatCounter;
        catCheckbox.value = entry['id'];

        newCategories.appendChild(catCheckbox);
        newCatCounter++;
    }
}

async function GetAllCategories() {
    try {
        const promise = await fetch('https://localhost:7233/GetAllCategories');

        if (!promise.ok) {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }

        const data = await promise.json();
        localStorage.setItem('Categories', JSON.stringify(data));
    }

    catch (error) {
        console.error(error);
    }
}

async function NewProduct() {
    const storeId = localStorage.getItem("StoreId");
    const name = document.getElementById("NewName").value;
    const amount = document.getElementById("NewAmount").value;

    let categoryIds = [];

    var divContent = document.getElementById('NewCategories').children;
    for (const entry of divContent) {

        if (entry.className == 'form-check-input') {
            if (entry.checked) {
                categoryIds.push(entry.value);
            }
        }
    }

    var jsonObject = {
        storeid: storeId,
        productid: '',
        name: name,
        categoryids: categoryIds,
        instock: amount
    }

    const json = JSON.stringify(jsonObject);

    await fetch('https://localhost:7233/NewProduct', {
        method: 'POST',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
        body: json
    }).then(response => {
        if (response.ok) {
            GetUpdatedStoreInfo();
        }
        else {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }
    });
}

async function GetUpdatedStoreInfo() {
    try {
        const storeId = localStorage.getItem("StoreId");
        const url = 'https://localhost:7233/GetStoreDataWithId?id=' + storeId;
        const promise = await fetch(url);

        if (!promise.ok) {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }

        const data = await promise.json();
        localStorage.setItem('StoreAndProducts', JSON.stringify(data));
        location.reload();
    }

    catch (error) {
        console.error(error);
    }
}

function ModifyProduct(storeId, element, index) {
    let categoryIds = [];

    var divContent = document.getElementById('categoryCell' + index).children;
    for (const entry of divContent) {
        if (entry.className == 'form-check-input') {
            if (entry.checked) {
                categoryIds.push(entry.value);
            }
        }
    }

    const newName = document.getElementById('ProductName' + index).value;
    const newAmount = document.getElementById('Amount' + index).value;

    var jsonObject = {
        storeid: storeId,
        productid: element['id'],
        name: newName,
        categoryids: categoryIds,
        instock: newAmount
    }

    const json = JSON.stringify(jsonObject);
    const url = "https://localhost:7233/ModifyProduct";

    fetch(url, {
        method: 'PUT',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
        body: json
    }).then(response => {
        if (response.ok) {
            GetUpdatedStoreInfo();
        }
        else {
            document.getElementById('Message').innerHTML = Translation("Modify", lang);
        }
    });
}

async function DeleteProduct(storeId, productId) {
    const url = 'https://localhost:7233/DeleteProduct?storeid=' + storeId + '&productid=' + productId;

    fetch(url, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    }).then(response => {
        if (!response.ok) {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }
        else {
            GetUpdatedStoreInfo();
        }
    });
}