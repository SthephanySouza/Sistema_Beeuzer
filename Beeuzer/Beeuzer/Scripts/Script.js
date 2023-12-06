// Caixas
function AumentarQtd() {
    let $valor = parseInt(document.getElementById('valor').value);

    let $soma = 1;

    let $result = $valor + $soma;
    document.getElementById('valor').value = $result;
    console.log($result);
}

function DiminuirQtd() {
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

// Carrinho
function Aumentar(idCar, User) {
    let valorElem = document.getElementById('valor-' + idCar);
    let totalElem = document.getElementById('total-' + idCar);
    let unitarioElem = document.getElementById('unitario-' + idCar);

    let valor = parseFloat(valorElem.value);
    let totalProd = parseFloat(totalElem.innerHTML.replace(',', '.'));
    let uni = parseFloat(unitarioElem.innerHTML.replace(',', '.'));

    let soma = 1;
    let result = valor + soma;
    totalProd = result * uni;

    totalElem.innerHTML = totalProd;
    valorElem.value = result;
    window.location.href = '/Carrinho/UpdateCarrinho?IdCar=' + idCar + '&Qtd=' + result + '&TotalProd=' + totalProd + '&NomeCli=' + User;
}

function Diminuir(idCar, User) {
    let valorElem = document.getElementById('valor-' + idCar);
    let totalElem = document.getElementById('total-' + idCar);
    let unitarioElem = document.getElementById('unitario-' + idCar);

    let valor = parseFloat(valorElem.value);
    let totalProd = parseFloat(totalElem.innerHTML.replace(',', '.'));
    let uni = parseFloat(unitarioElem.innerHTML.replace(',', '.'));

    let subtracao = 1;
    let result = valor - subtracao;

    if (result <= 0) {
        result = 1;
    }

    totalProd = result * uni;

    totalElem.innerHTML = totalProd;
    valorElem.value = result;

    window.location.href = '/Carrinho/UpdateCarrinho?IdCar=' + idCar + '&Qtd=' + result + '&TotalProd=' + totalProd + '&NomeCli=' + User;
}