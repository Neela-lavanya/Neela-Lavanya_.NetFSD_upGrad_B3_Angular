
const userName: string = "Anji";
let age: number = 20;
const email: string = "anji@gmail.com";
const isSubscribed: boolean = true;


let city = "Bangalore";   
let loginCount = 3;       


age++; 

const profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;


const isAdult: boolean = age >= 18;
const isEligibleForPremium: boolean = age > 18 && isSubscribed;

const hasFrequentLogin: boolean = loginCount > 2;

console.log("----- User Details -----");
console.log("Name:", userName);
console.log("Age:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);

console.log("\n----- Inferred Variables -----");
console.log("City:", city);
console.log("Login Count:", loginCount);

console.log("\n----- Profile Message -----");
console.log(profileMessage);

console.log("\n----- Conditions -----");
console.log("Is Adult:", isAdult);
console.log("Eligible for Premium:", isEligibleForPremium);
console.log("Frequent User:", hasFrequentLogin);