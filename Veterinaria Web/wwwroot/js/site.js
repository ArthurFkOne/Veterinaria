document.addEventListener('DOMContentLoaded', function () {
    const buttons = document.querySelectorAll('.botones button');
    const cards = document.querySelectorAll('.card');

    buttons.forEach(button => {
        button.addEventListener('click', () => {
            const category = button.className;
            filterCards(category);
        });
    });

    function filterCards(category) {
        cards.forEach(card => {
            const cardCategory = card.getAttribute('data-categoria');
            if (category === 'All' || category === cardCategory) {
                card.style.display = 'block';
            } else {
                card.style.display = 'none';
            }
        });
    }
});