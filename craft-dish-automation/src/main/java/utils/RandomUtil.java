package utils;

import java.security.SecureRandom;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Random;
import java.util.Set;

public class RandomUtil {

    private static final String ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public static <T> T getRandomItemFrom(List<T> list) {
        Set<T> uniqueElements = new HashSet<>(list);
        int i = new Random().nextInt(uniqueElements.size());
        return new ArrayList<>(uniqueElements).get(i);
    }

    public static <T> T getRandomItemFrom(List<T> list, T except) {
        Set<T> uniqueElements = new HashSet<>(list);
        uniqueElements.remove(except);
        int i = new Random().nextInt(uniqueElements.size());
        return new ArrayList<>(uniqueElements).get(i);
    }

    public static <T> T getRandomItemFrom(List<T> list, List<T> except) {
        Set<T> uniqueElements = new HashSet<>(list);
        uniqueElements.removeAll(except);
        int i = new Random().nextInt(uniqueElements.size());
        return new ArrayList<>(uniqueElements).get(i);
    }

    public static String getRandomStringWith(int length) {
        StringBuilder sb = new StringBuilder(length);
        SecureRandom rnd = new SecureRandom();
        for(int i = 0; i < length; i++)
            sb.append(ALPHABET.charAt(rnd.nextInt(ALPHABET.length())));
        return sb.toString();
    }
}