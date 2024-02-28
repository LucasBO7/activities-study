const elemento = document.querySelector('.message-container');

elemento.addEventListener('animationend', () => {
    elemento.style.animation = 'moving-flower-1 4s linear infinite';
});

elemento.style.animation = 'aparecer 6s forwards';