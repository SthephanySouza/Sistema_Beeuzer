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

function ready() {
    /* const qtsInputs = document.getElementById("section")
    for (var i = 0; i < qtsInputs.length; i++) {
        qtsInputs[i].addEventListener("change", checkIfInputIsNull)
    } */

    const addCarrinho = document.getElementById("AddCarrinho")
    for (var i = 0; i < addToCartButtons.length; i++) {
        addCarrinho[i].addEventListener("click", adicionar)
    }

    const compra = document.getElementById("Comprar")[0]
    compra.addEventListener("click", comprar)
}

function adicionar(event) {
    const button = event.target
    const productInfos = button.parentElement.parentElement

    const productImage = productInfos.getElementsByClassName("NomeProd")[0].src
    const productName = productInfos.getElementsByClassName("Tamanho")[0].innerText
    const productPrice = productInfos.getElementsByClassName("Cor")[0].innerText

    const produtoCarrinho = document.getElementsByClassName("cart-product-title")
    for (var i = 0; i < productsCartNames.length; i++) {
        if (produtoCarrinho[i].innerText === productName) {
            produtoCarrinho[i].parentElement.parentElement.getElementsByClassName("product-qtd-input")[0].value++
            updateTotal()
            return
        }
    }

    let newCartProduct = document.createElement("tr")
    newCartProduct.classList.add("cart-product")

    newCartProduct.innerHTML =
        `
      <td class="product-identification">
        <img src="${productImage}" alt="${productName}" class="cart-product-image">
        <strong class="cart-product-title">${productName}</strong>
      </td>
      <td>
        <span class="cart-product-price">${productPrice}</span>
      </td>
      <td>
        <input type="number" value="1" min="0" class="product-qtd-input">
        <button type="button" class="remove-product-button">Remover</button>
      </td>
    `

    const tableBody = document.querySelector(".cart-table tbody")
    tableBody.append(newCartProduct)
    updateTotal()

    newCartProduct.getElementsByClassName("remove-product-button")[0].addEventListener("click", removeProduct)
    newCartProduct.getElementsByClassName("product-qtd-input")[0].addEventListener("change", checkIfInputIsNull)
}

function makePurchase() {
    if (totalAmount === "0,00") {
        alert("Seu carrinho está vazio!")
    } else {
        alert(
            `
        Obrigado pela sua compra!
        Valor do pedido: R$${totalAmount}\n
        Volte sempre :)
      `
        )

        document.querySelector(".cart-table tbody").innerHTML = ""
        updateTotal()
    }
}