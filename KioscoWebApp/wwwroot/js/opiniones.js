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
        emailTxt.textContent = "Ingrese un email del colegio biro";
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