public class Aggregate {

    public static int max(int[] arr) {
        int max = Integer.MIN_VALUE;
        for(int i = 0; i < arr.length; i++) {
            if(arr[i] > max) {
                max = arr[i];
            }
        }
        return max;
    }

    public static int min(int[] arr) {
        int min = Integer.MAX_VALUE;
        for(int i = 0; i < arr.length; i++) {
            if(arr[i] < min) {
                min = arr[i];
            }
        }
        return min;
    }

    public static int sum(int[] arr) {
        int sum = 0;
        for(int i = 0; i < arr.length; i++) {
            sum += arr[i];
        }
        return sum;
    }

    public static double average(int[] arr) {
        int sum = sum(arr);
        return (double) sum / arr.length;
    }

    public static double standardDeviation(int[] arr) {
        double average = average(arr);
        double standardDeviation = 0;
        for(int i = 0; i < arr.length; i++) {
            standardDeviation += Math.pow(arr[i] - average, 2);
        }
        return Math.sqrt(standardDeviation / (arr.length - 1));
    }
}
