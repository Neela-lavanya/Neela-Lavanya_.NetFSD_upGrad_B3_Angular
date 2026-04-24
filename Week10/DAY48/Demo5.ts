// 1. Required parameter
function getWelcomeMessage(name: string): string {
    return "Welcome " + name + "!";
}

// 2. Optional parameter
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return name + " is " + age + " years old";
    } else {
        return name + "'s age is not provided";
    }
}

// 3. Default parameter
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    if (isSubscribed) {
        return name + " is subscribed";
    } else {
        return name + " is not subscribed";
    }
}

// 4. Function returning boolean
function isEligibleForPremium(age: number): boolean {
    return age > 18;
}

// 5. Arrow function
const getAccountUpdate = (name: string): string => {
    return "Hello " + name + ", your account is updated";
};

// 6. Lexical this
const notificationService = {
    appName: "MyApp",

    sendMessage: (msg: string): string => {
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