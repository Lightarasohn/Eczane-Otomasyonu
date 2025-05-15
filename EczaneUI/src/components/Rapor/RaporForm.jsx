import { Button, DatePicker, Form, Modal } from "antd";
const { RangePicker } = DatePicker;

import "./RaporForm.css";
import { useState } from "react";
import RaporOluştur from "../../api/RaporOlustur";

const RaporForm = ({ setIsOpen, satislar, raporlar, setRaporlar }) => {
  const [tarihAraligi, setTarihAraligi] = useState(null);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [message, setMessage] = useState("");

  const handleFormClick = async () => {
    if (tarihAraligi) {
      const [startDate, endDate] = tarihAraligi;
      const createdRapor = await RaporOluştur(
        startDate.format("YYYY-MM-DD"),
        endDate.format("YYYY-MM-DD"),
        satislar
      );

      if (createdRapor != null) {
        setRaporlar([...raporlar, createdRapor]);
        setMessage("Rapor başarıyla oluşturuldu.");
      } else {
        setMessage("Rapor oluşturulamadı.");
      }

      setIsModalOpen(true); // Bilgilendirme modali açılır
    } else {
      setMessage("Lütfen tarih aralığı seçiniz.");
      setIsModalOpen(true);
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

      <Modal
        open={isModalOpen}
        footer={null}
        onCancel={() => setIsModalOpen(false)}
        onOk={() => setIsModalOpen(false)}
        closable={false}
      >
        <h2>{message}</h2>
        <Button
          type="primary"
          danger
          onClick={() => setIsModalOpen(false)}
          style={{ marginTop: "10px" }}
        >
          Tamam
        </Button>
      </Modal>
    </>
  );
};

export default RaporForm;
