function Aumentar() {
    let $valor = parseInt(document.getElementById('valor').value);

    let $soma = 1;

    let $result = $valor + $soma;
    document.getElementById('valor').value = $result;
    console.log($result);
}

function Diminuir() {
    let $valor = parseInt(document.getElementById('valor').value);
    let $soma = 1;

    if ($valor <= 1) {
        document.getElementById('valor').value = 1;
    }
    else {
        let $result = $valor - $soma;
        document.getElementById('valor').value = $result;
        console.log($result);
    }
}