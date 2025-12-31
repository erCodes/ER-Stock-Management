const form = document.querySelector('#storeinfo');

document.addEventListener('DOMContentLoaded', function () {
    const lang = localStorage.getItem("Lang");
    CheckMode();

    document.getElementById("addNewStoreTitle").innerHTML = Translation("AddNewStoreTitle", lang);
    document.getElementById("mainPage").innerHTML = Translation("MainPage", lang);
    document.getElementById("nameLabel").innerHTML = Translation("Name", lang);
    document.getElementById("cityLabel").innerHTML = Translation("City", lang);
    document.getElementById("addressLabel").innerHTML = Translation("Address", lang);
    document.getElementById("supervisorLabel").innerHTML = Translation("Supervisor", lang);
    document.getElementById("phoneLabel").innerHTML = Translation("Phone", lang);
    document.getElementById("emailLabel").innerHTML = Translation("Email", lang);
    document.getElementById("submitButton").value = Translation("AddNew", lang);

    form.addEventListener('submit', (event) => {
        event.preventDefault();
        AddStore(lang);
    });
});

async function AddStore(lang) {
    const formData = new FormData(form);
    const jsonData = JSON.stringify(Object.fromEntries(formData));

    await fetch('https://localhost:7233/NewStore', {
        method: 'POST',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
        body: jsonData
    }).then(response => {
        if (response.ok) {
            document.getElementById('Message').innerHTML = Translation("AddStorePost", lang);
        }
        else {
            document.getElementById('Message').innerHTML = Translation("ErrorMessage", lang);
        }
    });
}