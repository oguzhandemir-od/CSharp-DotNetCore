document.addEventListener("DOMContentLoaded", function () {
  const investmentInput = document.getElementById("investment");
  const interestRateInput = document.getElementById("interest-rate");
  const timePeriodInput = document.getElementById("time-period");

  investmentInput.addEventListener("input", function () {
    updateInvestmentValue(this.value);
  });

  interestRateInput.addEventListener("input", function () {
    updateInterestRateValue(this.value);
  });

  timePeriodInput.addEventListener("input", function () {
    updateTimePeriodValue(this.value);
  });

  updateInvestmentValue(investmentInput.value);
  updateInterestRateValue(interestRateInput.value);
  updateTimePeriodValue(timePeriodInput.value);
});

function updateInvestmentValue(value) {
  document.getElementById("investment-value").innerText = `₺ ${parseFloat(
    value
  ).toLocaleString(`en-TR`)}`;
}

function updateInterestRateValue(value) {
  document.getElementById("interest-rate-value").innerText = `${parseFloat(
    value
  ).toFixed(1)}%`;
}

function updateTimePeriodValue(value) {
  document.getElementById("time-period-value").innerText = value;
}

function calculateFD() {
  const principal = parseFloat(document.getElementById("investment").value);
  const rateofInterest = parseFloat(
    document.getElementById("interest-rate").value
  );
  const timePeriod = parseFloat(document.getElementById("time-period").value);

  const n = 4;
  const totalAmount =
    principal * Math.pow(1 + rateofInterest / 100 / n, n * timePeriod);
  const interestEarned=totalAmount-principal;
  
  document.getElementById("invested-amount").innerText=`₺ ${principal.toLocaleString(`en-TR`)}`;
  document.getElementById("estimated-returns").innerText=`₺ ${Math.round(interestEarned).toLocaleString(`en-TR`)}`;
  document.getElementById("total-value").innerText=`₺ ${Math.round(totalAmount).toLocaleString(`en-TR`)}`;
}
