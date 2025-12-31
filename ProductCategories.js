const form = document.querySelector('#categoryInfo');

document.addEventListener('DOMContentLoaded', function () {
    const lang = localStorage.getItem("Lang");
    CheckMode();

    document.getElementById("mainPage").innerHTML = Translation("MainPage", lang);
    document.getElementById("productCategories").innerHTML = Translation("ProductCategories", lang);
    document.getElementById("categoryInfo").innerHTML = Translation("CategoryInfoText", lang);
    document.getElementById("categoryName").innerHTML = Translation("CategoryName", lang);
    document.getElementById("addNew").innerHTML = Translation("AddNew", lang);
    document.getElementById("NewCategoryName").placeholder = Translation("CategoryName", lang);

    GetAllCategories(lang);
    form.addEventListener('submit', (event) => {
        event.preventDefault();
    });
});

async function GetAllCategories(lang) {
    const promise = fetch('https://localhost:7233/GetAllCategories')
        .then(data => {
            if (!data.ok) {
                document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
                throw new Error("Promise chain cancelled");
            }
            return data.json();
        })
        .then(data => {
            if (!data) {
                document.getElementById('Message').innerHTML = Translation("CategoryGetNotFound", lang);
                throw new Error("Promise chain cancelled");
            }
            else {
                data.forEach((element, index) => CreateCategoryCell(element, index, lang))
            }

        })
        .catch((error) => {
            console.error(error)
        });
}

function CreateCategoryCell(element, index, lang) {
    const row = document.getElementById('categories');
    const cell = document.createElement('tr');
    const cellId = 'category' + index;
    cell.id = cellId;
    row.appendChild(cell);

    const createdCell = document.getElementById(cellId);

    const inputId = cellId + "Input";
    var input = document.createElement("input");
    input.type = "text";
    input.value = element["name"];
    input.placeholder = element["name"];
    input.id = inputId;
    input.maxLength = 50;
    createdCell.appendChild(input);

    var submit = document.createElement("input");
    submit.type = "submit";
    submit.className = "btn btn-primary";
    submit.value = Translation("Modify", lang);
    submit.onclick = () => { Modify(element, inputId) }
    createdCell.appendChild(submit);

    const boxId = cellId + "Delete";

    var deleteLabel = document.createElement("label");
    deleteLabel.setAttribute("for", boxId);
    deleteLabel.textContent = Translation("DeleteCategory", lang);
    createdCell.appendChild(deleteLabel);

    var deleteCheckbox = document.createElement("input");
    deleteCheckbox.type = "checkbox";
    deleteCheckbox.className = "form-check-input";
    deleteCheckbox.id = boxId;
    deleteLabel.appendChild(deleteCheckbox);

    var deleteButton = document.createElement("input");
    deleteButton.type = "button";
    deleteButton.className = "btn btn-danger";
    deleteButton.value = Translation("Delete", lang);
    deleteButton.onclick = () => { Delete(element["id"], boxId, lang) }
    createdCell.appendChild(deleteButton);
}

function NewCategory() {
    const lang = localStorage.getItem("Lang");
    const newCategoryName = document.getElementById("NewCategoryName").value;

    const url = "https://localhost:7233/NewCategory?name=" + newCategoryName;

    fetch(url, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' }
    }).then(response => {
        if (response.ok) {
            location.reload();
        }
        else {
            document.getElementById("Message").innerHTML = Translation("ErrorMessage", lang);
        }
    });

}

function Modify(category, inputId, lang) {
    const newName = document.getElementById(inputId).value;
    category["name"] = newName;
    const json = JSON.stringify(category);
    fetch("https://localhost:7233/ModifyCategory", {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: json
    }).then(response => {
        if (response.ok) {
            location.reload();
        }
        else {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }
    });
}

function Delete(categoryId, boxId, lang) {
    if (!document.getElementById(boxId).checked) {
        return;
    }

    const url = "https://localhost:7233/DeleteCategory?id=" + categoryId;

    fetch(url, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: categoryId
    }).then(response => {
        if (response.ok) {
            location.reload();
        }
        else {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }
    });
}