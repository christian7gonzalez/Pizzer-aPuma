﻿//MisFunciones para front end
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