    const toggleBtn = document.querySelector('.menu-sanduiche')
const toggleBtnIcon = document.querySelector('.menu-sanduiche i')
const dropDownMenu = document.querySelector('.dropdown')

toggleBtn.onclick = function () {
    dropDownMenu.classList.toggle('aberto')
    const estaAberto = dropDownMenu.classList.contains('aberto')

    toggleBtnIcon.classList = estaAberto
    ? 'fa-solid fa-xmark'
    : 'fa-solid fa-bars' 
}