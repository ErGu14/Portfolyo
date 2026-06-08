window.portfolio = {
    initTypewriter: function (elementId, words) {
        try {
            const element = document.getElementById(elementId);
            if (!element) return;

            let wordIndex = 0;
            let charIndex = 0;
            let isDeleting = false;
            let typingDelay = 150;
            let erasingDelay = 100;
            let newTextDelay = 2000;

            function type() {
                try {
                    const currentWord = words[wordIndex];
                    
                    if (isDeleting) {
                        element.textContent = currentWord.substring(0, charIndex - 1);
                        charIndex--;
                    } else {
                        element.textContent = currentWord.substring(0, charIndex + 1);
                        charIndex++;
                    }

                    let typeSpeed = isDeleting ? erasingDelay : typingDelay;

                    if (!isDeleting && charIndex === currentWord.length) {
                        typeSpeed = newTextDelay;
                        isDeleting = true;
                    } else if (isDeleting && charIndex === 0) {
                        isDeleting = false;
                        wordIndex = (wordIndex + 1) % words.length;
                        typeSpeed = 500;
                    }

                    setTimeout(type, typeSpeed);
                } catch (e) {
                    console.error("Typewriter runtime error: ", e);
                }
            }

            setTimeout(type, newTextDelay + 250);
        } catch (error) {
            console.error("Failed to init Typewriter: ", error);
        }
    },

    initScrollObservers: function () {
        try {
            // Navbar Scroll Effect
            const navbar = document.getElementById('main-navbar');
            if (navbar) {
                window.addEventListener('scroll', () => {
                    if (window.scrollY > 50) {
                        navbar.classList.add('scrolled');
                    } else {
                        navbar.classList.remove('scrolled');
                    }
                });
            }

            // Sticky CV Button observer
            const heroSection = document.getElementById('hero-section');
            const cvButton = document.getElementById('floating-cv-btn');
            
            if (heroSection && cvButton) {
                const observer = new IntersectionObserver((entries) => {
                    entries.forEach(entry => {
                        if (!entry.isIntersecting) {
                            cvButton.classList.add('visible');
                        } else {
                            cvButton.classList.remove('visible');
                        }
                    });
                }, { threshold: 0.1 });
                observer.observe(heroSection);
            }

            // Reveal on scroll elements
            const revealElements = document.querySelectorAll('.reveal');
            if (revealElements.length > 0) {
                const revealObserver = new IntersectionObserver((entries) => {
                    entries.forEach(entry => {
                        if (entry.isIntersecting) {
                            entry.target.classList.add('active');
                        }
                    });
                }, { threshold: 0.1, rootMargin: "0px 0px -50px 0px" });

                revealElements.forEach(el => revealObserver.observe(el));
            }
        } catch (error) {
            console.error("Failed to init Scroll Observers: ", error);
        }
    },

    initParallax: function () {
        try {
            window.addEventListener('scroll', () => {
                const heroContent = document.getElementById('hero-content');
                if (heroContent) {
                    const scrolled = window.scrollY;
                    if (scrolled < 1000) { // Sadece ekrandayken çalışsın
                        heroContent.style.transform = `translateY(${scrolled * 0.3}px)`;
                        heroContent.style.opacity = 1 - (scrolled / 600);
                    }
                }
            });
        } catch (error) {
            console.error("Failed to init Parallax: ", error);
        }
    }
};
