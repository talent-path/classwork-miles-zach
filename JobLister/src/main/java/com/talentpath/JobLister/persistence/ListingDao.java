package com.talentpath.JobLister.persistence;

import com.talentpath.JobLister.models.Listing;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface ListingDao extends JpaRepository<Listing, Integer> {

    Optional<List<Listing>> findByListingNameContainingIgnoreCase(String name);

    Optional<List<Listing>> findByCityAndStateAllIgnoreCase(String city, String state);

    Optional<List<Listing>> findByEmploymentTypeIgnoreCase(String type);

    Optional<List<Listing>> findByIndustryIgnoreCase(String industry);

    Optional<List<Listing>> findByCompanyContainingIgnoreCase(String company);

    Optional<List<Listing>> findBySalaryBetween(Integer low, Integer high);
}
