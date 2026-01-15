import * as readline from 'readline';

const inputreader = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

function getAdjacentCountries(countryCode: string) {
    const countryMap : {[key : string] : string}= {
        IN: "India",
        US: "United States",
        CN: "China",
        RU: "Russia",
        FR: "France",
        DE: "Germany",
        BR: "Brazil",
        AU: "Australia",
        NZ: "New Zealand",
        JP: "Japan",
        GB: "United Kingdom"
    };

    const countryName = countryMap[countryCode.toUpperCase()];

    if (countryName) {
        console.log(countryName);
    } else {
        console.log("Country code not found");
    }
}

inputreader.question('Enter country code (e.g., IN, US, NZ): ', (input: string) => {
    getAdjacentCountries(input.toUpperCase());
    inputreader.close();
});