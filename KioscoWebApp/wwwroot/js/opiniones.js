const searchBar = document.getElementById('searchBar');
searchBar.addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        var search = searchBar.value;
        console.log('Search Value: ' + search);
        url = `https://localhost:7202/Products/Index/?name=` + encodeURIComponent(search);
        document.location.href = url;
    }
});

const email = document.getElementById('email');
const formResponse = document.getElementById('formResponse');
const sendButton = document.getElementById('submitBut');
sendButton.addEventListener('click', function (e) {


    if (!email.value.includes("@colegiobiro.edu.ar")) {
        email.value = "";
        email.textContent = "Ingrese un email del colegio biro";
    }

});

document.getElementById('myForm').addEventListener('submit', async function (event) {
    event.preventDefault();  //Previniendo la conf. default del formulario
    const form = event.target;
    const formData = new FormData(form);

    try {
        let response = await fetch(form.action, {
            method: form.method,
            body: formData,
            headers: {
                'Accept': 'application/json'
            }
        });

        if (response.ok) {
            document.getElementById('formResponse').innerText = "El mensaje ha sido enviado de manera exitosa!";
            form.reset();  //Reseteando el formulario despues de mandarlo
        } else {
            document.getElementById('formResponse').innerText = "No se ha podido enviar el mensaje.";
        }
    } catch (error) {
        console.log(error);
        document.getElementById('formResponse').innerText = "Un error ha ocurrido mientras se estaba enviando el formulario.";
    }
});

function closePage() {
    window.location.href = '/Products/Index/';
}   

const alfajoresButton = document.getElementById('alfajoresBut');
const bebidasButton = document.getElementById('bebidasBut');
const snacksButton = document.getElementById('snacksBut');
const chiclesButton = document.getElementById('chiclesBut');
const dulcesButton = document.getElementById('dulcesBut');
const galletitasButton = document.getElementById('galletitasBut');

function GetCategory(catId) {
    let categoryId = catId;
    window.location.href = `/Products/Index/?categoryId=${categoryId}`;
}
alfajoresButton.addEventListener('click', function () {
     let catId = 1;
    GetCategory(catId);
});

bebidasButton.addEventListener('click', function () {
    let catId = 2;
    GetCategory(catId);
});

snacksButton.addEventListener('click', function () {
     let catId = 3;
    GetCategory(catId);
});

chiclesButton.addEventListener('click', function () {
    let catId = 4;
    GetCategory(catId);
});

dulcesButton.addEventListener("click", function () {
    let catId = 5;
    GetCategory(catId)

});
galletitasButton.addEventListener('click', function () {
    let catId = 6;
    GetCategory(catId);
});