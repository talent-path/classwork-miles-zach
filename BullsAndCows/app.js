const generateNumber = function() {
    const num = Math.trunc(Math.random() * (9876 - 1023 + 1) + 1023);
    return (/([0-9]).*?\1/).test(num) ? generateNumber() : num;
}

let currentNumber = generateNumber().toString();

const buildPage = function() {
    const bodyTags = document.getElementsByTagName("body");
    const gameDiv = document.createElement("div");
    const title = document.createElement("h1");
    title.innerText = "Guessing Game";
    gameDiv.appendChild(title);
    gameDiv.appendChild(document.createElement("br"));

    for(let i = 0; i < 4; i++) {
        const numberDiv = document.createElement("div");
        numberDiv.id = i;
        numberDiv.style = `height: 100px; width: 100px; 
        border: 1px solid black; display: inline-block; margin-right: 10px;
        font-size: 100px; text-align: center;`
        gameDiv.appendChild(numberDiv);
    }

    gameDiv.appendChild(document.createElement("br"));

    const input = document.createElement("input");
    input.type = "text";
    input.placeholder = "Enter a four digit number";
    input.style.display = "inline-block";
    
    const guessButton = document.createElement("button");
    guessButton.addEventListener('click', validateInput);
    guessButton.innerText = "Guess!";
    guessButton.style.display = "inline-block";
    guessButton.id = "guessButton";

    const resetButton = document.createElement("button");
    resetButton.addEventListener('click', resetGame);
    resetButton.innerText = "Reset";
    resetButton.style.display = "inline-block";

    gameDiv.appendChild(input);
    gameDiv.appendChild(guessButton);
    gameDiv.appendChild(resetButton);
    
    bodyTags[0].appendChild(gameDiv);
};

const validateInput = function() {
    const userInput = document.getElementsByTagName("input")[0].value;
    /^\d{4}$/.test(userInput) 
        ? compareDigits(userInput) 
        : alert("Please enter a four digit number with unique digits!");
}

const resetGame = function() {
    for(let i = 0; i < 4; i++) {
        const div = document.getElementById(i);
        div.innerText = "";
        div.style.backgroundColor = "white";
    }
    currentNumber = generateNumber().toString();
    document.getElementById("guessButton").disabled = false;
}

const compareDigits = function(num) {
    const userDigits = num.split("");
    let count = 0;
    for(let i = 0; i < 4; i++) {
        const div = document.getElementById(i);
        div.innerText = userDigits[i];
        if(userDigits[i] === currentNumber[i]) {
            count++;
            div.style.backgroundColor = "green";
        } else if(currentNumber.includes(userDigits[i])) {
            div.style.backgroundColor = "yellow";
        } else {
            div.style.backgroundColor = "red";
        }
    }

    if(count === 4) {
        alert(`You guessed it! The number was ${currentNumber}`);
        document.getElementById("guessButton").disabled = true;
    }
}


buildPage();