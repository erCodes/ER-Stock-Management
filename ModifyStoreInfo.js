const form = document.querySelector('#storeinfo');
let lang = "";
form.addEventListener('submit', (event) => {
    event.preventDefault();
    ModifyStore();
});

document.addEventListener('DOMContentLoaded', () => RenderPage(), false);

async function RenderPage() {
    const storeData = JSON.parse(localStorage.getItem('StoreAndProducts'));
    lang = localStorage.getItem("Lang");
    await CheckMode();

    document.getElementById("mainPage").innerHTML = Translation("MainPage", lang);
    document.getElementById("modifyStoreInfo").innerHTML = Translation("ModifyStoreInfo", lang);
    document.getElementById("nameLabel").innerHTML = Translation("Name", lang);
    document.getElementById("cityLabel").innerHTML = Translation("City", lang);
    document.getElementById("addressLabel").innerHTML = Translation("Address", lang);
    document.getElementById("supervisorLabel").innerHTML = Translation("Supervisor", lang);
    document.getElementById("phoneLabel").innerHTML = Translation("Phone", lang);
    document.getElementById("emailLabel").innerHTML = Translation("Email", lang);
    document.getElementById("submitButton").value = Translation("Modify", lang);

    document.getElementById('Id').value = storeData['id'];
    let name = document.getElementById('Name');
    name.setAttribute('placeholder', storeData['name']);
    let city = document.getElementById('City');
    city.setAttribute('placeholder', storeData['city']);
    let address = document.getElementById('Address');
    address.setAttribute('placeholder', storeData['address']);
    let supervisor = document.getElementById('Supervisor');
    supervisor.setAttribute('placeholder', storeData['supervisor']);
    let phone = document.getElementById('Phone');
    phone.setAttribute('placeholder', storeData['phone']);
    let email = document.getElementById('Email');
    email.setAttribute('placeholder', storeData['email']);
}

async function ModifyStore() {
    const formData = new FormData(form);
    const jsonData = JSON.stringify(Object.fromEntries(formData));

    await fetch('https://localhost:7233/ModifyStore', {
        method: 'PUT',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
        body: jsonData
    }).then(response => {
        if (response.ok) {
            document.getElementById('Message').innerHTML = Translation("StoreModified", lang);
        }
        else {
            document.getElementById('Message').innerHTML = Translation("ErrorMesssage", lang);
        }
    });
}