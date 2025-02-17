// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
setTimeout(function () {
    $(".alert").fadeOut("slow", function () {
        $(this).alert("close");
    });
}, 5000);

//Função para gerar um alerta que sempre o valor digitado no campo de notas do aluno for menor que 0
function AlertaSonoro() {
    var som = new Audio('/sounds/Alert-3.mp3');
    som.play()
    setTimeout(function () {
        alert("O valor não pode ser menor do que 0");
    }, 300);
}

$(document).ready(function () {
    function calcularMedia() {
        // Obtém os valores dos campos de entrada
        var ciencias = parseFloat(document.getElementById("ciencias").value.replace(",", ".")) || 0;
        var geografia = parseFloat(document.getElementById("geografia").value.replace(",", ".")) || 0;
        var estrangeira = parseFloat(document.getElementById("estrangeira").value.replace(",", ".")) || 0;
        var matematica = parseFloat(document.getElementById("matematica").value.replace(",", ".")) || 0;
        var portugues = parseFloat(document.getElementById("portugues").value.replace(",", ".")) || 0;
        var mediaColor = window.document.getElementById("media");
        var inputColor = window.document.querySelector('.inputNota');

        // Calcula a média
        var media = (ciencias + geografia + estrangeira + matematica + portugues) / 5;

        // Atualiza o campo de média
        document.getElementById("media").value = media.toFixed(2);

        mediaColor.value = media.toFixed(2);

        if (ciencias < 0 || geografia < 0 || estrangeira < 0 || matematica < 0 || portugues < 0) {
            AlertaSonoro();
            // Adiciona a classe 'inputError' ao campo com valor inválido
            $(this).addClass('inputError');
            window.document.getElementById('media').value = "Recalculando...";
        } else {
            $(this).removeClass('inputError');
        }

        if (media >= 7) {
            mediaColor.style.color = "green";
            mediaColor.style.fontWeight = "800";
        } else if (media >= 1 && media <= 6.99)
        {
            mediaColor.style.color = "red";
            mediaColor.style.fontWeight = "800";
        }else {
            mediaColor.style.color = "black";
            mediaColor.style.fontWeight = "800";
        }
    }

    // Adiciona evento 'input' a cada campo para recalcular a média em tempo real
    $("#ciencias, #geografia, #estrangeira, #matematica, #portugues").on("input", calcularMedia);

    // Calcula a média inicialmente
    calcularMedia();
});
