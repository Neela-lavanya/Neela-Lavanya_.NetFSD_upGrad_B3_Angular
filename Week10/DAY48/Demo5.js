"use strict";
// 1. Required parameter
function getWelcomeMessage(name) {
    return "Welcome " + name + "!";
}
// 2. Optional parameter
function getUserInfo(name, age) {
    if (age !== undefined) {
        return name + " is " + age + " years old";
    }
    else {
        return name + "'s age is not provided";
    }
}
// 3. Default parameter
function getSubscriptionStatus(name, isSubscribed = false) {
    if (isSubscribed) {
        return name + " is subscribed";
    }
    else {
        return name + " is not subscribed";
    }
}
// 4. Function returning boolean
function isEligibleForPremium(age) {
    return age > 18;
}
// 5. Arrow function
const getAccountUpdate = (name) => {
    return "Hello " + name + ", your account is updated";
};
// 6. Lexical this
const notificationService = {
    appName: "MyApp",
    sendMessage: (msg) => {
        return "[" + notificationService.appName + "] " + msg;
    }
};
// -------- Execution --------
let age = 22;
let isSubscribed = true;
// using function
console.log(getWelcomeMessage("Lavi"));
console.log(getUserInfo("Lavi", age));
console.log(getUserInfo("Lavi"));
console.log(getSubscriptionStatus("Lavi", isSubscribed));
console.log(getSubscriptionStatus("Lavi"));
// boolean function
console.log("Eligible (function):", isEligibleForPremium(age));
// variable (different name to avoid error)
const premiumStatus = age > 18 && isSubscribed;
console.log("Eligible (variable):", premiumStatus);
console.log(getAccountUpdate("Lavi"));
console.log(notificationService.sendMessage("Welcome to app"));
