const url = "https://localhost:5001/api/beanvariety/";

const contentTarget = document.querySelector("#theBeans");
const button = document.querySelector("#run-button");

button.addEventListener("click", () => {
    getAllBeanVarieties()
        .then(beanVarieties => {
            renderBeans(beanVarieties);
        })
});

function getAllBeanVarieties() {
    return fetch(url).then(resp => resp.json());
};

const renderBeans = (beans) => {
    const beansToStrings = beans.map((bean) => {
        return `
        <article class="criminal">
        <h2>${bean.name}</h2>
        <h2>${bean.region}</h2>
        <h2>${bean.notes}</h2>
        </article>
        `
    }).join("")

    contentTarget.innerHTML = beansToStrings
};

