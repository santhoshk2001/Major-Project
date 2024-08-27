document.addEventListener('DOMContentLoaded', function () {
    const toggle = document.getElementById('toggleDarkMode');
    const body = document.querySelector('body');

    toggle.addEventListener('click', function () {
        body.classList.toggle('dark-mode');

        if (body.classList.contains('dark-mode')) {
            body.style.background = 'black';
            body.style.color = 'white';
        } else {
            body.style.background = 'white';
            body.style.color = 'black';
        }
    });
});
