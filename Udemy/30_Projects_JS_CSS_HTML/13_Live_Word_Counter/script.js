const inputTextArea = document.getElementById("input-textarea");
const charCount = document.getElementById("char-count");
const wordCount = document.getElementById("word-count");

inputTextArea.addEventListener("input", () => {
  // Character Count
  charCount.textContent = inputTextArea.value.length;

  // Word Count
  const txt = inputTextArea.value.trim();
  const wordArray = txt.split(/\s+/);

  let wordCountValue = 0;
  for (let i = 0; i < wordArray.length; i++) {
    if (wordArray[i] != "") {
      wordCountValue++;
    }
  }

  wordCount.textContent = wordCountValue;
});
