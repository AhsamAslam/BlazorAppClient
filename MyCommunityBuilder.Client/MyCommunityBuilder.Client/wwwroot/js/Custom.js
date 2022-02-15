function FunctionOpen(id1, id2, id3) {
    var x = document.getElementById(id1);
    document.getElementById('hamburger').style.display = 'none';
    document.getElementById('cross').style.display = 'block';

    if (x.style.display === "none") {

        x.style.display = "block";

    } else {
        x.style.display = "none";
    }
    return false;
}
function FunctionClose(id1, id2, id3) {
    var x = document.getElementById(id1).style.display = 'none';

    document.getElementById('hamburger').style.display = 'block';
    document.getElementById('cross').style.display = 'none';

}