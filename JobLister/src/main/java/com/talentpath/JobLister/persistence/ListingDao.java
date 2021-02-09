package com.talentpath.JobLister.persistence;

import com.talentpath.JobLister.models.Listing;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ListingDao extends JpaRepository<Listing, Integer> {
}
