package com.talentpath.JobLister.dao;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.persistence.ListingDao;
import org.junit.jupiter.api.BeforeEach;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ActiveProfiles;

import java.util.List;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class ListingDaoTests {

    @Autowired
    ListingDao listingDao;

    @BeforeEach
    void setup() {
        listingDao.deleteAll();
    }

    
}
