
document.getElementById('bnts').onclick = windowOnloadAdd;

function windowOnloadAdd() {
    $.get("Home/Index", function (data) {
        document.getElementById('DataTime').html(data);
    });
}