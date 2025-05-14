const SatisOlustur = async (satisEmailIlaclar) => {
    const email = {
        AliciEmail: satisEmailIlaclar.email
    };
    const ilaclar = satisEmailIlaclar.ilaclar;

    const satisRequestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(email)
    };

    try {
        const satisResult = await fetch("http://localhost:5169/api/satis", satisRequestOptions);
        if (satisResult.ok) {
            const satis = await satisResult.json(); // ✅ await ekledik

            for (const ilac of ilaclar) {
                console.log(ilac);
                const satisIlacBody = {
                    IlacId: ilac.id,
                    SatisId: satis.id,
                    Miktar: ilac.miktar
                };

                const satisIlacRequestOptions = {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(satisIlacBody)
                };

                try {
                    const satisIlacResult = await fetch("http://localhost:5169/api/satis-ilac", satisIlacRequestOptions);
                    if (satisIlacResult.ok) {
                        const result = await satisIlacResult.json(); // ✅ await ekledik
                        console.log("İlaç eklendi:", result);
                    } else {
                        console.log(`İlaç ${ilac.adi} satışa eklenemedi`);
                    }
                } catch (error) {
                    console.error(`İlaç ${ilac.adi} için istek hatası:`, error);
                }
            }
        } else {
            console.error("Satış oluşturulamadı.");
        }
    } catch (e) {
        console.error("Satış isteği sırasında hata:", e);
    }
};

export default SatisOlustur;