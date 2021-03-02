//MisFunciones para front end
// En html se llama onkeypress="javascript:return solonDecimales(event)"
function soloDecimales(e) {

    var key;

    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }

    if ((key < 48 || key > 57) && key != 44) {
        return false;
    }
    return true;
}

function LimpiarTexto(txt) {

    if (txt.value == "*Tipo" || txt.value == "*Menu") {
        txt.value = "";
    }
    else if (txt.value == "" || txt.value == "") {
        if (txt.id == "txtSearch") {
            txtBox.value = "*Manu";
        }
        else {
            txtBox.value = "*Tipo";
        }
    }
}

function LimpiarTextoClear(txt) {

    txt.value = "";
}
/*
//Asigno el evento "click" del botón para provoar el copiado
document.getElementById('btnCopiar').addEventListener('click', copiarAlPortapapeles);

//Función que lanza el copiado del código
function copiarAlPortapapeles(ev) {
    var codigoACopiar = document.getElementById('txtNombreCliente').value;    //Elemento a copiar
    //Debe estar seleccionado en la página para que surta efecto, así que...
    var seleccion = document.createRange(); //Creo una nueva selección vacía
    seleccion.selectNodeContents(codigoACopiar);    //incluyo el nodo en la selección
    //Antes de añadir el intervalo de selección a la selección actual, elimino otros que pudieran existir (sino no funciona en Edge)
    window.getSelection().removeAllRanges();
    window.getSelection().addRange(seleccion);  //Y la añado a lo seleccionado actualmente
    try {
        var res = document.execCommand('copy'); //Intento el copiado
        if (res)
            exito();
        else
            fracaso();

        mostrarAlerta();
    }
    catch (ex) {
        excepcion();
    }
    window.getSelection().removeRange(seleccion);
}
*/