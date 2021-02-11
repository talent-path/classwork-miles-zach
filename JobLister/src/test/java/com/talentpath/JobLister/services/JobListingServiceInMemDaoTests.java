package com.talentpath.JobLister.services;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.context.annotation.Profile;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@Profile({"serviceTest"})
public class JobListingServiceInMemDaoTests {

    @Autowired
    JobListingService service;

    @Test
    void fakeTest() {
        fail();
    }
    
}
