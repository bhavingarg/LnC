public class Customer {
    private String firstName;
    private String lastName;
    private Wallet myWallet;
    
    public String getFirstName() { 
        return firstName; 
    }
    
    public String getLastName() { 
        return lastName; 
    }
    
    public void makePayment(float amount) {
        if (myWallet.getTotalMoney() >= amount) {
            myWallet.subtractMoney(amount);
        } else {
            // come back later
        }
    }
}