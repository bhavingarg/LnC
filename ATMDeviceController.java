public class ATMDeviceController {

    private static final String PRIMARY_DEVICE_ID = "DEV1";
    private static final int DEVICE_SUSPENDED = -1;
    private static final String WIFI_CONNECTED = "CONNECTED";

    private class DeviceHandle {
        private static final String INVALID = "INVALID";
        private final String STATUS = "VALID";
    }

    private class DeviceRecord {
        public int getStatus() {
            return 0;
        }

        public String getWifiConnection() {
            return WIFI_CONNECTED;
        }
    }

    public void withdraw(String accountId, double amount) throws Exception {
        try {
            processWithdrawal(accountId, amount);
        } catch (DeviceSuspendedException | InsufficientFundsException | NetworkConnectionException e) {
            handleWithdrawalError(e);
            throw e;
        }
    }

    private void processWithdrawal(String accountId, double amount) throws Exception {
        DeviceHandle handle = getValidHandle();
        DeviceRecord record = retrieveDeviceRecord(handle);

        verifyDeviceStatus(record);
        verifyConnectivity(record);
        verifyBalance(accountId, amount);

        dispenseCash(handle, amount);
    }

    private DeviceHandle getValidHandle() {
        DeviceHandle handle = getHandle(PRIMARY_DEVICE_ID);
        if (handle.STATUS == DeviceHandle.INVALID) {
            throw new RuntimeException("Invalid Device Handle");
        }
        return handle;
    }

    private void verifyDeviceStatus(DeviceRecord record) throws DeviceSuspendedException {
        if (record.getStatus() == DEVICE_SUSPENDED) {
            throw new DeviceSuspendedException();
        }
    }

    private void verifyConnectivity(DeviceRecord record) throws NetworkConnectionException {
        if (record.getWifiConnection() != WIFI_CONNECTED) {
            throw new NetworkConnectionException();
        }
    }

    private void verifyBalance(String accountId, double amount) throws InsufficientFundsException {
        if (getBalance(accountId) < amount) {
            throw new InsufficientFundsException();
        }
    }

    private void dispenseCash(DeviceHandle handle, double amount) {
        // Logic to dispense cash
    }

    private DeviceRecord retrieveDeviceRecord(DeviceHandle handle) {
        // Logic to retrieve device record
        return new DeviceRecord();
    }

    private DeviceHandle getHandle(String deviceId) {
        // Logic to get device handle
        return new DeviceHandle();
    }

    private double getBalance(String accountId) {
        // Logic to get account balance
        return 0.0;
    }

    private void handleWithdrawalError(Exception e) {
        // Log the error or notify a specific subsystem
    }
}
