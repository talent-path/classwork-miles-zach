const generateNumber = function() {
    const num = Math.trunc(Math.random() * (9876 - 1234 + 1) + 1234);
    return (/([0-9]).*?\1/).test(num) ? generateNumber() : num;
}

const buildPage = function() {
    const bodyTags = document.getElementsByTagName("body");
    const gameDiv = document.createElement("div");
    const title = document.createElement("h1");
    title.innerText = "Guessing Game";
    gameDiv.appendChild(title);
    gameDiv.appendChild(document.createElement("br"));

    for(let i = 0; i < 4; i++) {
        const numberBlock = document.createElement("div");
        numberBlock.style = `height: 100px; width: 100px; 
        border: 1px solid black; display: inline-block; margin-right: 10px;`
        gameDiv.appendChild(numberBlock);
    }

    gameDiv.appendChild(document.createElement("br"));

    const input = document.createElement("input");
    input.type = "text";
    input.placeholder = "Enter a four digit number";
    input.style.display = "inline-block";
    
    const button = document.createElement("button");
    button.addEventListener('click', validateInput);
    button.innerText = "Guess!";
    button.style.display = "inline-block";

    gameDiv.appendChild(input);
    gameDiv.appendChild(button);
    //last step
    bodyTags[0].appendChild(gameDiv);
};

const validateInput = function() {
    const userInput = document.getElementsByTagName("input")[0].value;
    console.log(userInput);
    // return /^\d{4}$/.test(userInput) ? compareDigits(userInput) : null;
}

const compareDigits = function(num) {
    console.log(num);
}


buildPage();