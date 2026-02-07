<template>
  <div class="landing">
    <HeroSection />
    <ServicesSection />
    <AboutSection />
    <ContactSection />
    <FooterSection />
  </div>
</template>

<script setup>
import HeroSection from '@/components/landing/HeroSection.vue'
import ServicesSection from '@/components/landing/ServicesSection.vue'
import AboutSection from '@/components/landing/AboutSection.vue'
import ContactSection from '@/components/landing/ContactSection.vue'
import FooterSection from '@/components/landing/FooterSection.vue'
</script>

<style scoped>
.landing {
  font-family: 'Inter', sans-serif;
  background: #f8fafc;
}
</style>
