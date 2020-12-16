
function showAlterMess(type, mess) {
    var alertClass = document.getElementById("alertClass");
    alertClass.classList.add(type);
    var messAlter = document.getElementById("messAlter");
    messAlter.innerText = mess;
    var listMessBox = document.getElementById("listMessBox");
    listMessBox.classList.remove("cls-display-none");
    myVar = setTimeout(closeAlert, 3000);
}
function closeAlert() {
   // document.getElementById("btnCloseAlert").click(); // Click on the checkbox
    //$("#listMessBox").load(location.href + " #listMessBox");
    var listMessBox = document.getElementById("listMessBox");
    listMessBox.classList.add("cls-display-none");
}
//$(function () {
//    $('#AlertBox').removeClass('hide');
//    $('#AlertBox').delay(1000).slideUp(500);
//});
