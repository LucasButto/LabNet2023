document.addEventListener("DOMContentLoaded", function () {
  const minNumber = 1;
  const maxNumber = 50;
  let targetNumber = Math.floor(Math.random() * maxNumber) + 1;
  let attempts = 0;
  let score = 0;

  let highscore = localStorage.getItem("highscore");

  const body = document.body;
  const input = document.querySelector(".guess-field-input");
  const hintsList = document.querySelectorAll(".hint");
  const actualScore = document.querySelector(".actual");
  const highscoreDisplay = document.querySelector(".highscore");
  const errorMessage = document.querySelector(".error-message");

  if (!highscore) {
    console.log("Entre");
    highscore = 0;
  } else {
    highscore = parseInt(highscore);
  }

  highscoreDisplay.textContent = highscore;

  function updateHighscore() {
    highscoreDisplay.textContent = highscore;
    localStorage.setItem("highscore", highscore);
  }

  function updateHints(guess) {
    const hintItem = hintsList[attempts - 1];

    const hintIcon = document.createElement("span");
    hintIcon.classList.add("material-symbols-rounded");

    if (guess < targetNumber) {
      hintIcon.textContent = "north";
    } else if (guess > targetNumber) {
      hintIcon.textContent = "south";
    }

    hintItem.innerHTML = "";
    hintItem.appendChild(hintIcon);

    hintItem.appendChild(document.createTextNode(` ${guess}`));
  }

  function checkGuess(guess) {
    const resultText = document.querySelector(".result-text");

    if (guess === targetNumber) {
      body.classList.add("win");
      confetti();
      score++;
      if (score > highscore) {
        highscore = score;
        updateHighscore();
      }
      resultText.textContent = `Congratulations! The number was ${targetNumber}.`;
      document.querySelector(".reset-button").style.display = "block";
      document.querySelector(".reset-button").textContent = "Next";
      input.setAttribute("disabled", "true");
      document
        .querySelector(".guess-submit-button")
        .setAttribute("disabled", "true");
    } else {
      attempts++;
      updateHints(guess);
      if (attempts >= 5) {
        body.classList.add("lose");
        score = 0;
        attempts = 0;
        resultText.textContent = `Better luck next time. The number was ${targetNumber}.`;
        document.querySelector(".reset-button").style.display = "block";
        document.querySelector(".reset-button").textContent = "Restart";
        input.setAttribute("disabled", "true");
        document
          .querySelector(".guess-submit-button")
          .setAttribute("disabled", "true");
      }
    }
    actualScore.textContent = score;
  }

  document.querySelector("form").addEventListener("submit", function (e) {
    e.preventDefault();
    const guess = parseInt(input.value, 10);
    if (guess >= minNumber && guess <= maxNumber) {
      checkGuess(guess);
      errorMessage.textContent = "";
    } else {
      errorMessage.textContent = `Please enter a number between ${minNumber} and ${maxNumber}.`;
    }
    input.value = "";
  });

  function resetGame() {
    body.classList.remove("win", "lose");
    targetNumber = Math.floor(Math.random() * maxNumber) + 1;
    attempts = 0;
    for (let hint of hintsList) {
      hint.textContent = "-";
    }
    document.querySelector(".reset-button").style.display = "none";
    input.value = "";
    input.removeAttribute("disabled");
    document.querySelector(".guess-submit-button").removeAttribute("disabled");

    document.querySelector(".result-text").textContent = "";
  }

  document
    .querySelector(".reset-button")
    .addEventListener("click", function () {
      resetGame();
    });

  resetGame();
});
