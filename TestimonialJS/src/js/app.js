let index = 0;

// json - pmuch tthe same as es6 classes
const customers = [
    { image: './images/people/customer-0.png', name: 'John Doe', quote: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis neque reprehenderit laborum, corporis explicabo assumenda. Porro impedit consectetur animi, reprehenderit recusandae sapiente at aliquam reiciendis modi ipsam rerum suscipit distinctio?' },
    { image: './images/people/customer-1.png', name: 'Sandy Su', quote: 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock' },
    { image: './images/people/customer-2.png', name: 'Amy Zing', quote: 'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don\'t look even slightly believable.' },
    { image: './images/people/customer-3.png', name: 'Tyrell F', quote: 'If you are going to use a passage of Lorem Ipsum, you need to be sure there isn\'t anything embarrassing hidden in the middle of text.' },
    { image: './images/people/customer-4.png', name: 'Wanda M', quote: 'Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.' },
];

const refreshCard = () => {
    document.getElementById('customer-img').src = customers[index].image;
    document.getElementById('customer-name').textContent = customers[index].name;
    document.getElementById('customer-text').textContent = customers[index].quote;
}

document.getElementById('prevBtn').addEventListener('click', (e) => {
    index = ((index === 0) ? customers.length : index) - 1;
    refreshCard();
});

document.getElementById('nextBtn').addEventListener('click', (e) => {
    index = ++index % customers.length;
    refreshCard();
});

// -----------------------------------------------------------
refreshCard();