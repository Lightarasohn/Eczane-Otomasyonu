import { Button, DatePicker, Form } from "antd";
const { RangePicker } = DatePicker;

import "./RaporForm.css";
import { useState } from "react";
import RaporOluştur from "../../api/RaporOlustur";

const RaporForm = ({ setIsOpen, satislar, raporlar, setRaporlar }) => {
  const [tarihAraligi, setTarihAraligi] = useState(null);

  const handleFormClick = async () => {
    if (tarihAraligi) {
      const [startDate, endDate] = tarihAraligi;
      const createdRapor = await RaporOluştur(startDate.format("YYYY-MM-DD"), endDate.format("YYYY-MM-DD"), satislar) 
      
      createdRapor != null ? setRaporlar([...raporlar, createdRapor]) : setRaporlar([...raporlar]);
    } else {
      console.log("Tarih aralığı seçilmedi");
    }
  };

  return (
    <>
      <Form>
        <Form.Item label="Tarih Aralığı:">
          <RangePicker
            onChange={(dates) => {
              setTarihAraligi(dates);
            }}
          />
        </Form.Item>
      </Form>

      <div style={{ display: "flex", gap: "10px" }}>
        <Button type="primary" onClick={handleFormClick}>
          Raporu Oluştur
        </Button>
        <Button type="primary" danger onClick={() => setIsOpen(false)}>
          Kapat
        </Button>
      </div>
    </>
  );
};

export default RaporForm;
